<template>
    <v-card>
        <v-row style="align-items: center;">
            <v-col md="5">
                <v-card-text style="font-size: 20px;">Trang sức</v-card-text>
            </v-col>
            <v-col md="3">
                <v-btn icon="mdi-plus" size="small" @click="dialogAdd = true"></v-btn>
            </v-col>
        </v-row>

        <v-table>
            <thead>
                <tr>
                <th class="text-center">
                    ID
                </th>
                <th class="text-left">
                    Tên
                </th>
                <th class="text-left">
                    Loại
                </th>
                <th class="text-left">
                    Cân nặng
                </th>
                <th class="text-left">
                    Size
                </th>
                <th class="text-left">
                    Màu sắc
                </th>
                <th class="text-left">
                    Giá
                </th>
                <th class="text-center">
                    
                </th>
                <th class="text-center">
                    
                </th>
                </tr>
            </thead>
            <tbody>
                <tr
                v-for="item in listJewelry"
                :key="item.jewelryId"
                >
                    <td class="text-center">{{ item.jewelryId }}</td>
                    <td>{{ item.jewelryName }}</td>
                    <td>{{ item.categoryName}}</td>
                    <td>{{ item.jewelryWeight }}</td>
                    <td>{{ item.jewelrySize }}</td>
                    <td>{{ item.jewelryColor }}</td>
                    <td>$ {{ item.jewelryPrice }}</td>
                    <td>
                        <v-btn @click="dialogDetail = true, currentItem = item" color="orange" class="mr-3" icon size="x-small">
                            <v-icon>mdi-eye</v-icon>
                        </v-btn>
                        <v-btn color="red" class="mr-3" icon size="x-small" @click="dialogEdit = true, currentItem=item">
                            <v-icon>mdi-pencil</v-icon>
                        </v-btn>
                        <v-btn color="blue" class="mr-3" icon size="x-small" @click="dialogDelete = true, jewelryId = item.jewelryId">
                            <v-icon>mdi-delete</v-icon>
                        </v-btn>
                    </td>
                </tr>
            </tbody>
        </v-table>
        
    </v-card>
    <admin-detail-jewelry
        :dialogDetail="dialogDetail"
        @close="dialogDetail = false"
        :currentItem = "currentItem"
    />

    <admin-add-jewlery
        :dialogAdd = "dialogAdd"
        @close="dialogAdd = false"
        @updateData="getJewelries"
    />

    <edit-jewelry
        :dialogEdit="dialogEdit"
        @close="dialogEdit = false"
        @updateData="getJewelries"
        :currentItem = "currentItem"
    />

    <v-dialog
          v-model="dialogDelete"
          width="auto"
        >
          <v-card>
            <v-card-text>Ban có chắc muốn xóa không?</v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="green-darken-1"
                variant="text"
                @click="dialogDelete = false"
              >
                Hủy
              </v-btn>
              <v-btn
                color="green-darken-1"
                variant="text"
                @click="this.deleteJewelry(jewelryId), dialogDelete = false"
              >
                Xác nhận
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
  </template>
  <script>
  import { mapGetters, mapActions, mapState } from 'vuex'
  import AdminAddJewlery from './AdminAddJewlery.vue'
  import AdminDetailJewelry from './AdminDetailJewelry.vue'
import EditJewelry from './EditJewelry.vue'
    export default {
  components: { AdminDetailJewelry, AdminAddJewlery, EditJewelry },
      data () {
        return {
          jewelryId: '',
          page: 1,
          dialogDetail: false,
          dialogAdd: false,
          dialogDelete: false,
          dialogEdit: false,
          currentItem: '',
        }
      },
      computed:{
        ...mapGetters(['listJewelry']),
      },

      created(){
        this.getJewelries();
      },

      methods:{
        ...mapActions(['getJewelries','deleteJewelry']),
    }
  }
  </script>