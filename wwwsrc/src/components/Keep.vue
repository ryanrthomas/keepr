<template>
    <div class="keep m-3">
        <div class="card" style="width: 18rem;">
            <img class="card-img-top" src="https://placehold.it/300x200" alt="Card image cap">
            <div class="card-body">
                <p class="card-text"><b>K</b> 0&nbsp<i class="fas fa-share"></i> 0&nbsp<i class="fas fa-eye"></i> 0</p>
                <h5 class="card-title">(Title of keep)</h5>
                <button class="btn btn-danger m-1"><b>K</b></button>
                <button class="btn btn-warning m-1"><i class="fas fa-share"></i></button>
                <button class="btn btn-primary m-1"><i class="fas fa-eye"></i></button>
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
        computed: {},
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