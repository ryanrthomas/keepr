<template>
    <div class="list-keeps container-fluid">
        <div class="row">
            <div class="mb-4 col-12 col-md-6 col-lg-3" v-for="vault in vaults">
                <p>{{vault}}</p>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: "list-vaults",
        props: [],
        mounted() { },
        data() {
            return {}
        },
        computed: {
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {},
        components: {}
    }
</script>


<style>

</style>