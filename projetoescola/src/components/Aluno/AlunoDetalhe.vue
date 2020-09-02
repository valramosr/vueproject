<template>
  <div v-if="!loading" class="container">
    <div class="form-group">
      <div class="row">
        <titulo :texto="`Aluno: ${aluno.nome} `" />
      </div>
      <table class="table table-sm table-hover table-striped">
        <tbody>
          <tr>
            <td>Matrícula</td>
            <td>
              <label for="">{{ aluno.id }}</label>
            </td>
          </tr>
          <tr>
            <td>Nome</td>
            <td>
              <label v-if="visualisando"> {{ aluno.nome }}</label>
              <input
                v-else
                class="form-control"
                v-model="aluno.nome"
                type="text"
              />
            </td>
          </tr>
          <tr>
            <td>Sobrenome</td>
            <td>
              <label v-if="visualisando">{{ aluno.sobrenome }}</label>
              <input
                v-else
                class="form-control"
                v-model="aluno.sobrenome"
                type="text"
              />
            </td>
          </tr>
          <tr>
            <td>Data Nascimenmto</td>
            <td>
              <label v-if="visualisando">{{ aluno.dataNasc }}</label>
              <input
                v-else
                class="form-control"
                v-model="aluno.dataNasc"
                type="text"
              />
            </td>
          </tr>
          <tr>
            <td>Professor</td>
            <td>
              <label v-if="visualisando" for="">{{
                aluno.professor.nome
              }}</label>
              <select v-else v-model="aluno.professor.id" name="" id="">
                <option
                  v-for="(professor, index) in professores"
                  :key="index"
                  v-bind:value="professor.id"
                >
                  {{ professor.nome }}
                </option>
              </select>
            </td>
          </tr>
        </tbody>
      </table>
      <div style="margin-top: 10px">
        <button class="btn btn-primary" @click="editar()">Editar</button>
        <div v-if="!visualisando">
          <button class="btn btn-success" @click="salvar(aluno)">Salvar</button>
          <button class="btn btn-danger" @click="cancelar()">Cancelar</button>
        </div>
      </div>
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
      aluno: {},
      professores: [],
      idAluno: this.$route.params.id,
      visualisando: true,
      loading: true,
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then((res) => res.json())
        .then((professor) => {this.professores = professor;
        this.carregarAluno();
        
        });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/aluno/${this.idAluno}`)
        .then((res) => res.json())
        .then((aluno) => {this.aluno = aluno;
        this.loading = false;
        
        });
    },

    editar() {
      this.visualisando = !this.visualisando;
    },
    salvar(_aluno) {
      let _alunoEditar = {
        id: _aluno.id,
        nome: _aluno.nome,
        sobrenome: _aluno.sobrenome,
        dataNasc: _aluno.dataNasc,
        professorid: _aluno.professor.id,
      };
      this.$http
        .put(`http://localhost:5000/api/aluno/${_alunoEditar.id}`, _alunoEditar)
        .then((res) => res.json())
        .then(aluno => this.aluno = aluno)
        .then(()=> this.visualisando = true);  

        this.visualisando = !this.visualisando;   
    },
    cancelar() {
      this.visualisando = !this.visualisando;
    },
  },
};
</script>

<style scoped></style>
