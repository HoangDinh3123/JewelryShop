<template>
  <nav>
    <v-navigation-drawer
      >
        <v-list>
          <v-list-item
            prepend-icon="mdi-diamond-stone"
            title="Admin"
          ></v-list-item>
        </v-list>

        <v-divider></v-divider>

        <v-list density="compact" nav>
          <v-list-item to="/admin/dashboard" prepend-icon="mdi-view-dashboard" title="Tổng quát" value="dashboard"></v-list-item>
          <v-list-item to="/admin/categories" prepend-icon="mdi-treasure-chest" title="Loại sản phẩm" value="categories"></v-list-item>
          <v-list-item to="/admin/jewelries" prepend-icon="mdi-treasure-chest" title="Sản phẩm" value="products"></v-list-item>
          <v-list-item to="/admin/orders" prepend-icon="mdi-order-bool-ascending" title="Đơn hàng" value="orders"></v-list-item>
          <v-list-item to="/admin/customers" prepend-icon="mdi-briefcase-account" title="Khách hàng" value="customers"></v-list-item>

        </v-list>
      </v-navigation-drawer>
    </nav>
</template>

<script>
export default {
    name: 'SideBar',
    data(){
        return{

        }
    }
}
</script>

<style>
</style>