<template>
  <div class="home text-center">
    <h1 class="mt-2">Welcome, {{username}}.</h1>
    <h4>You can post keeps and manage your vaults here.</h4>
    <form @submit.prevent="addKeep">
      <input class="m-2" type="text" v-model="newKeep.name" placeholder="Title" required><br>
      <input class="m-2" type="text" v-model="newKeep.description" placeholder="Description"><br>
      <input class="m-2" type="text" v-model="newKeep.img" placeholder="Image URL"><br>
      <button type="submit" class="btn btn-success mb-3">Post Keep</button>
    </form>
    <list-keeps></list-keeps>
  </div>
</template>

<script>
  import ListKeeps from "@/components/ListKeeps.vue"
  export default {
    name: "home",
    mounted() {
      // Blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch('getKeeps')
    },
    data() {
      return{
        newKeep: {
          name: "",
          description: "",
          img: "",
          userId: 1,
          shares: 0,
          views: 0
        }
      }
    },
    computed: {
      username() {
        return this.$store.state.user.username
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      addKeep() {
        this.$store.dispatch('addKeep', this.newKeep)
      }
    },
    components: {
      ListKeeps
    }
  };
</script>

<style>

</style>