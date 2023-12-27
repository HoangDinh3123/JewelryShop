<template>
    <v-toolbar style=" background-color: white; border-bottom: solid 1px black; margin-bottom: 40px;" >
      <v-toolbar-items>
       <v-btn
         v-for="item in nav_left"
         :key="item.icon"
         :title="item.title"
         flat
         style="font-size: 13px;"
         :to="item.url"
       >{{ item.text }}</v-btn>
      </v-toolbar-items>
      
      <v-bar-title style="font-size: 30px; font-weight: bold; margin-left: 250px;">GOLDSMITH</v-bar-title>
      <v-spacer></v-spacer>

      <v-toolbar-items>

      <v-btn to="/customers/cart" class="text-none" stacked>
        <v-badge :content="cart.length" color="error">
          <v-icon>mdi mdi-cart-outline</v-icon>
        </v-badge>
      </v-btn>

      <!-- Show navbar user -->
      <v-btn
        v-if="user"
          title="user"
          flat
          @click.stop="drawer = !drawer">
          <v-icon>mdi mdi-account</v-icon>
      </v-btn>

      <v-btn
        v-if="!user"
          title="user"
          flat
          to="/login">
          <v-icon>mdi mdi-login</v-icon>
      </v-btn>

      <v-card style="z-index: 1; ">
        <!-- Logged -->
          <v-layout >
            <v-navigation-drawer
              v-model="drawer"
              temporary
              class="logged"
              v-if="user"
            >
              <v-list-item
                prepend-avatar="https://randomuser.me/api/portraits/men/78.jpg"
                :title="user.user.userName"
              ></v-list-item>

              <v-divider></v-divider>

              <v-list density="compact" nav>
                <v-list-item to="/customers/order" prepend-icon="mdi-forum" title="Đơn hàng của bạn" value="your_order"></v-list-item>
                <v-list-item style="display:;">
                  <v-btn @click="this.logout" title="Logout" style="padding: 10px;">
                    Logout
                    <v-icon style="margin-left: 5px;">mdi mdi-logout</v-icon>
                  </v-btn>
                </v-list-item>
              </v-list>
            </v-navigation-drawer>
          </v-layout>
        <!-- Logged -->

      </v-card>
      </v-toolbar-items>
    </v-toolbar>
</template>

<script>
import { mapActions, mapGetters, mapState } from 'vuex'
export default {
name: 'App',
data(){
  return{
    drawer: null,
    search: '',
    loading: false
  }
},
  computed: {
      ...mapGetters(['cart', 'user', 'listJewelry']),

  },
  methods:{
    ...mapActions(['logout']),
  }

};
</script>

<style>

</style>