<template>
    <div class="list-vaults container-fluid">
        <div class="row">
            <div class="vault mb-4 pb-3 pr-3 col-12 col-sm-6 col-md-3" v-for="vault in vaults">
                <h3>{{vault.name}}</h3>
                <h5>{{vault.description}}</h5>
                <p class="text-right m-0" ><i class="fas fa-plus pr-3" title="Add keep to vault"></i><i class="fas fa-trash" title="Delete vault"></i></p>
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