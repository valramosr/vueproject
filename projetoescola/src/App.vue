<template>
  <div id="app">
    <div>
       <app-nav-bar />
    </div>
      <router-view :key="$route.fullPath"></router-view>
    </div>
</template>

<script>
 import Alunos from './components/Aluno/Alunos.vue'
 import Professor from './components/Professor/Professor'
 import Sobre from './components/Sobre/Sobre'
import navBar from './components/_nave/Nav'


export default {
  name: 'App',
  components: {
    /* eslint-disable vue/no-unused-components */
     Alunos,
     Professor,
     Sobre,
    'app-nav-bar': navBar
  }
}
</script>

<style>

</style>
