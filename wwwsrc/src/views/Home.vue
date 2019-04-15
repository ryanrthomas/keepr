<template>
  <div class="home">
    <h1 class="mt-2">Welcome, {{username}}.</h1>
    <h4>You can post keeps and manage your vaults here.</h4>
    <form>
      <input class="m-2" type="text" placeholder="Title"><br>
      <input class="m-2" type="text" placeholder="Image URL"><br>
      <button type="submit" class="btn btn-success">Post Keep</button>
    </form>
    <keep></keep>
    <keep></keep>
  </div>
</template>

<script>
  import Keep from "@/components/Keep.vue"
  export default {
    name: "home",
    mounted() {
      // Blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    computed: {
      username() {
        return this.$store.state.user.username
      },
      keeps() {
        return this.$store.state.user.keeps
      }
    },
    components: {
      Keep
    }
  };
</script>

<style>

</style>