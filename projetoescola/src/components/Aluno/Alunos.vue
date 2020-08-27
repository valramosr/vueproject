<template>
  <div>
    <div class="container">
      <div class="row">
        <titulo :texto="professorid != undefined ? 'Professor: ' + professor.nome : 'Todos os Alunos'" />
      </div>
      <div v-if="professorid != undefined"  class="row">
        <div class="col-lg-8">
          <div class="form-group">
            <input
              class="form-control"
              placeholder="Nome do Aluno(a)"
              id="ex3"
              type="text"
              v-model="nome"
            />
          </div>
        </div>
        <div class="col-lg-4">
          <button class="btn btn-primary" @click="addAluno()">Adicionar</button>
        </div>
      </div>

      <table class="table table-sm table-hover table-striped">
        <thead>
          <th>Matricula</th>
          <th>Nome</th>
          <th>Opcoes</th>
        </thead>
        <tbody v-if="alunos.length">
          <tr v-for="(aluno, index) in alunos" :key="index">
            <!-- <td>{{ index + 1 }}</td> -->
            <td>{{ aluno.id }}</td>
              <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
                {{ aluno.nome }} {{ aluno.sobrenome }}
              </router-link>
     
            <td>
              <button class="btn btn-danger" @click="remover(aluno)">
                Remover
              </button>
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          Nenhum Aluno encontrado!
        </tfoot>
      </table>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo,
  },

  data() {
    return {
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      professor:{},
      nome: "",
      alunos: [],
    };
  },
  created() {
    if (this.professorid) {
      this.carregarProfessores()
      this.$http
        .get(`http://localhost:3000/alunos?professor.id=${this.professorid}`)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:3000/alunos")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sonbrenome: "",
        professor:{
          id: this.professor.id,
          nome: this.professor.nome 
        }
      };

      this.$http
        .post("http://localhost:3000/alunos", _aluno)
        .then((res) => res.json())
        .then((alunoRetorno) => {
          this.alunos.push(alunoRetorno);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    carregarProfessores() {
      this.$http
        .get("http://localhost:3000/professores/" + this.professorid)
        .then((res) => res.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>

<style scoped></style>
