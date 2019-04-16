<template>
    <div class="list-keeps container-fluid">
        <div class="row">
            <div class="p-0 col-12 col-md-6 col-lg-3" v-for="keep in keeps">
                <div class="card" style="width: auto;">
                    <img class="card-img-top" :src="keep.img" alt="Card image cap">
                    <div class="card-body">
                        <h5 class="card-title">{{keep.name}}</h5>
                        <p class="card-description">{{keep.description}}</p>
                        <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> {{keep.shares}}&nbsp<i
                                class="fas fa-eye"></i> {{keep.views}}
                        </p>
                        <button class="btn btn-danger m-1" title="Keep"><b>K</b></button>
                        <button class="btn btn-warning m-1" title="Share"><i class="fas fa-share"></i></button>
                        <button class="btn btn-primary m-1" title="View"><i class="fas fa-eye"></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: "list-keeps",
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
        border-radius: 0%;
    }
</style>