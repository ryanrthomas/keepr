<template>
    <div class="list-vaults container-fluid">
        <div class="row">
            <div class="vault mb-4 pb-3 pr-3 col-12 col-sm-6 col-md-3" v-for="vault in vaults">
                <h3>{{vault.name}}</h3>
                <h5>{{vault.description}}</h5>
                <vault-keeps></vault-keeps>
                <p class="mt-0 text-right m-0"><i class="add-keep fas fa-plus pr-3" title="Add keep to vault"></i><i
                        class="delete-vault fas fa-trash" @click="deleteVault" title="Delete vault"></i></p>
            </div>
        </div>
    </div>
</template>


<script>
    import VaultKeeps from "@/components/VaultKeeps.vue"
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
        methods: {
            deleteVault(vault) {
                confirm("Are you sure you want to delete this vault?")
            }
        },
        components: {
            VaultKeeps
        }
    }
</script>


<style>
    .vault {
        margin-top: -5px !important;
        margin-right: -4px !important;
        padding: 20px;
        margin-bottom: 35px;
        background-color: rgba(0, 0, 0, 0.5);
        border-color: white;
        border-width: 4px;
        border-style: solid;
    }

    .add-keep,
    .delete-vault {
        cursor: pointer;
    }
</style>