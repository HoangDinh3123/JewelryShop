<template>
    <v-card>
        <v-row style="align-items: center;">
            <v-col md="5">
                <v-card-text style="font-size: 20px;">Trang sức</v-card-text>
            </v-col>
        </v-row>

        <v-table>
            <thead>
                <tr>
                <th class="text-center">
                    ID
                </th>
                <th class="text-left">
                    Tên khách hàng
                </th>
                <th class="text-left">
                    Email
                </th>
                <th class="text-left">
                    Số điện thoại
                </th>
                <th class="text-center">
                    
                </th>
                <th class="text-center">
                    
                </th>
                </tr>
            </thead>
            <tbody>
                <tr
                v-for="item in listCustomer"
                :key="item.userId"
                >
                    <td class="text-center">{{ item.userId }}</td>
                    <td>{{ item.userName }}</td>
                    <td>{{ item.userEmail}}</td>
                    <td>{{ item.userPhone }}</td>
                </tr>
            </tbody>
        </v-table>

        
    </v-card>
  </template>
  <script>
  import { mapGetters, mapActions, mapState } from 'vuex'
    export default {
      data () {
        return {
          page: 1,
        }
      },
      computed:{
        ...mapGetters(['listCustomer']),
      },

      created(){
        this.getCustomers();
      },

      methods:{
        ...mapActions(['getCustomers']),
    }
  }
  </script>