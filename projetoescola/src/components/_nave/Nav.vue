<template>
    <div class="barraTop">
        <nav class="marginPrincipal">
            <router-link to="/professores">Professorres</router-link>
            <router-link to="/todosalunos">Alunos</router-link>
            <router-link to="/sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style scoped>
.barraTop{
    background-color: rgb(230, 230, 230);
}
.marginPrincipal{

}
nav{
    padding: 20px 20px 20px 0px;
}
nav a{
    padding: 10px;
    text-decoration: none;
    background-color: white;
    border-radius: 3px;
    color: rgb(0, 110, 255);
    font-weight: bold;
    margin-right: 15px;
}

</style>