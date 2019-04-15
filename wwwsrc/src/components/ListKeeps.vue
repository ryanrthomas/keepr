<template>
    <div class="list-keeps row">
        <div class="m-2 col-3" v-for="keep in keeps">
            <div class="card" style="width: auto;">
                <img class="card-img-top" :src="keep.img" alt="Card image cap">
                <div class="card-body">
                    <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> {{keep.shares}}&nbsp<i class="fas fa-eye"></i> 0
                    </p>
                    <h5 class="card-title">{{keep.name}}</h5>
                    <button class="btn btn-danger m-1"><b>K</b></button>
                    <button class="btn btn-warning m-1"><i class="fas fa-share"></i></button>
                    <button class="btn btn-primary m-1"><i class="fas fa-eye"></i></button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: "keep",
        props: [],
        mounted() { },
        data() {
            return {}
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            }
        },
        methods: {},
        components: {}
    }
</script>


<style>
    .card {
        border-style: solid;
        border-width: thin;
        border-color: black;
    }
</style>