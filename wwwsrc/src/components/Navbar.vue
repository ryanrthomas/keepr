<template>
    <div class="navbar">
        <div class="navbar">
            <h1 class="navbar">Keepr</h1>
            <button type="button" data-toggle="modal" data-target="#loginModal" class="btn m-2 btn-outline-primary"
                @click="">Sign In</button>
            <button type="button" data-toggle="modal" data-target="#registerModal" class="btn m-2 btn-primary"
                @click="">Register</button>
        </div>
        <!-- MODAL -->
        <div id="loginModal" tabindex="-1" role="dialog">
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
                            <input type="email" placeholder="Email" required>
                            <input type="password" placeholder="Password" required>
                            <button class="btn btn-secondary m-3" type="submit">Login</button>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Log In</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="registerModal" tabindex="-1" role="dialog">
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
                            <input type="text" placeholder="Name" required>
                            <input type="email" placeholder="Email" required>
                            <input type="password" placeholder="Password" required>
                            <button class="btn btn-secondary m-1" type="submit">Create Account</button>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Register</button>
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
        methods: {},
        components: {

        }
    }
</script>


<style>
    .modal-content {
        color: black;
    }
</style>