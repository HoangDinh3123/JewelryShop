<template>
    <div style="padding: 0 20px;">
        <Navbar></Navbar>
        <v-app>
            <v-main>
                <router-view></router-view>
            </v-main>
            <Footer></Footer>
        </v-app>
    </div>
  </template>
  
  <script>
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'
  export default {
      name: 'CustomerLayout',
      components: {
        Navbar,
        Footer,
      }
  }
  </script>
  
  <style>
  
  </style>