<template>
  <div>
    <v-app style="background-color: #e6fff9;">
      <side-bar />
      <top />
      <v-main>
        <v-container class="py-3 px-6">
          <router-view />
        </v-container>
      </v-main>
    </v-app>
  </div>
</template>

<script>
import SideBar from '@/components/SideBar.vue'
import Top from '@/components/Top.vue'
export default {
    name: 'AdminLayout',
    components: {
        SideBar,
        Top,
    }
}
</script>

<style>

</style>