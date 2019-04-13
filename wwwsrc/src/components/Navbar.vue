<template>
    <div class="navbar">
        <div class="navbar">
            <h1 class="navbar">Keepr</h1>
            <button type="button" data-toggle="modal" data-target="#loginModal" class="btn m-2 btn-outline-primary">Sign
                In</button>
            <button type="button" data-toggle="modal" data-target="#registerModal"
                class="btn m-2 btn-primary">Register</button>
        </div>
        <!-- MODAL -->
        <div id="loginModal" class="modal" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Sign In</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <input class="m-1" type="email" placeholder="Email" required>
                            <input class="m-1" type="password" placeholder="Password" required><br>
                            <button class="btn btn-primary m-1" type="submit">Log In</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div id="registerModal" class="modal" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Create an account</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <input class="m-1" type="text" placeholder="Name" required>
                            <input class="m-1" type="email" placeholder="Email" required>
                            <input class="m-1" type="password" placeholder="Password" required><br>
                            <button class="btn btn-primary m-1" type="submit">Create Account</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: "navbar",
        props: [],
        mounted() { },
        data() {
            return {}
        },
        computed: {},
        methods: {
            // showLoginModal() {
            //     $('#loginModal').modal()
            // },
            // showRegisterModal() {
            //     $('#registerModal').modal()
            // },
        },
        components: {

        }
    }
</script>


<style>
    .modal-content {
        color: black;
    }
</style>