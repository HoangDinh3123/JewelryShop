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
                <th class="text-left">
                    ID
                </th>
                <th class="text-left">
                    Tên
                </th>
                <th class="text-center">
                    
                </th>
                <th class="text-center">
                    
                </th>
                </tr>
            </thead>
            <tbody>
                <tr
                v-for="item in listCategory"
                :key="item.categoryId"
                >
                    <td>{{ item.categoryId }}</td>
                    <td>{{ item.categoryName }}</td>
                    <td>
                        <v-btn color="red" class="mr-3" icon size="x-small" @click="dialogEdit = true, currentItem=item">
                            <v-icon>mdi-pencil</v-icon>
                        </v-btn>
                        <v-btn color="blue" class="mr-3" icon size="x-small" @click="dialogDelete = true, categoryId = item.categoryId">
                            <v-icon>mdi-delete</v-icon>
                        </v-btn>
                    </td>
                </tr>
            </tbody>
        </v-table>

        
    </v-card>

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
                @click="this.deleteCategory(categoryId), dialogDelete = false"
              >
                Xác nhận
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>


    <add-category
        :dialogAdd = "dialogAdd"
        @close="dialogAdd = false"
        @updateData="getCategories"
    />
    <edit-category
        :dialogEdit="dialogEdit"
        @close="dialogEdit = false"
        @updateData="getCategories"
        :currentItem = "currentItem"
    />

  </template>
<script>
    import { mapGetters, mapMutations, mapActions } from 'vuex'
    import AddCategory from './AddCategory.vue'
    import EditCategory from './EditCategory.vue'
    export default {
      components: { AddCategory, EditCategory },
          data () {
            return {
              categoryId: '',
              page: 1,
              dialogAdd: false,
              dialogEdit: false,
              dialogDelete: false,
              currentItem: ''
            }
          },
          computed:{
            ...mapGetters(['listCategory'])
          },
          created(){
            this.getCategories();
          },
          methods:{
            ...mapActions(['getCategories', 'deleteCategory']),
          },
      }
  </script>