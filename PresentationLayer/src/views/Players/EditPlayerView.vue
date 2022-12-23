<template>
    <form ref="form" class="col-sm" @submit.prevent="editPlayer" method="post">
        <div class="row ">
            <div class=" mx-auto">
                <h2>Player</h2>
                <input placeholder="Input name" type="text" v-model="player.name" minlength="3" maxlength="50" class="form-control" required />
                <button type="submit" class="button-submit btn btn-success ">Save</button>
            </div>
            <ErrorMessage :message="errorMessage"></ErrorMessage>
        </div>
    </form>
</template>

<script>
    import PlayersService from "../../services/PlayersService";
    export default {
        emits: ['close', 'get-players'],
        props: ['playerId'],
        data() {
            return {
                player: {
                    id: this.playerID,
                    name: '',
                },
                errorMessage: ''
            }
        },
        created() {
            this.getPlayer();
        },
        computed: {
            isValid() {
                return this.player.name;
            }
        },
        methods: {
            async getPlayer() {
                PlayersService.GetByIdShort(this.playerId).then(response => {
                    this.player = response.data;
                })
                    .catch(e => {
                        console.log(e);
                    });
            },
            async editPlayer() {
                if (!this.isValid) return false
                PlayersService.Edit(this.player)
                    .then(response => {
                        if (response.status == 200) {
                            this.$emit('close');
                            this.$emit('get-players');
                            return { ok: true }
                        }
                    })
                    .catch(e => {
                        this.errorMessage = e.response;
                    });
            },
        }
    }
</script>

<style lang="scss" scoped>
</style>
