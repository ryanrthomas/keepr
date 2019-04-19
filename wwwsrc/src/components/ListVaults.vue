<template>
    <div class="list-vaults container-fluid">
        <div class="row">
            <div class="vault mb-4 pb-3 pr-3 col-12 col-sm-6 col-md-3" v-for="vault in vaults">
                <h3>{{vault.name}}</h3>
                <h5>{{vault.description}}</h5>
                <div v-if="vaultKeeps.length">
                    <p class="pb-1"><i>({{vaultKeeps.length}} keeps)</i></p>
                    <vault-keeps></vault-keeps>
                </div>
                <div v-else>
                    <p><i>(No keeps in this vault)</i></p>
                </div>
                <div class="mt-0 text-right m-0">
                    <button class="btn btn-dark m-1 shadow" @click="deleteVault(vault)" title="Delete vault"><i
                            class="fas fa-trash"></i></button>
                </div>
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
            vaultKeeps() {
                return this.$store.state.vaultKeeps
            },
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {
            deleteVault(vault) {
                if (confirm("Are you sure you want to delete this vault?")) {
                    this.$store.dispatch("deleteVault", vault)
                }
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