<template>
    <v-app-bar>
        <v-spacer></v-spacer>
        <v-toolbar-item>
            <v-btn variant="text" icon size="x-small">
                <v-badge color="red" content="5">
                    <v-icon>mdi-bell</v-icon>
                </v-badge>
            </v-btn>
            
            <v-menu
                rounded
            >
                <template v-slot:activator="{ props }">
                <v-btn
                    icon
                    v-bind="props"
                >
                    <v-avatar
                    color="brown"
                    size="small"
                    >
                        <v-img
                            src="https://cdn.vuetifyjs.com/images/john.jpg"
                            alt="John"
                        ></v-img>
                    </v-avatar>
                </v-btn>
                </template>
                <v-card>
                <v-card-text>
                    <div class="mx-auto text-center">
                    <v-avatar
                        color="brown"
                    >
                    </v-avatar>
                    <v-divider class="my-3"></v-divider>
                    <v-divider class="my-3"></v-divider>
                    <v-btn
                        rounded
                        variant="text"
                        @click="this.logout"
                    >
                        Đăng xuất
                    </v-btn>
                    </div>
                </v-card-text>
                </v-card>
            </v-menu>
        </v-toolbar-item>
    </v-app-bar>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
    name: 'TopBar',
    data: () => ({
    }),
    computed: {
        ...mapGetters(['user']),

    },
    methods:{
        ...mapActions(['logout']),
    }
}
</script>

<style>
</style>