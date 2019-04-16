<template>
    <div class="list-vaults container-fluid">
        <div class="row">
            <div class="vault mb-4 col-12 col-md-6" v-for="vault in vaults">
                <h3>{{vault.name}}</h3>
                <h5>{{vault.description}}</h5>
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
.vault{
    padding: 20px;
    margin-bottom: 35px;
    background-color: rgba(0, 0, 0, 0.5);
    border-color: white;
    border-width: 4px;
    border-style: solid;
}
</style>