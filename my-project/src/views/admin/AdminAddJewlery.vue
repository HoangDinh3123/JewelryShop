<template>
    <v-dialog
      v-model="dialog"
      persistent
      width="1024"
    >
        <v-card>
            <v-card-title>
                <span class="text-h5">Thêm Mới Trang Sức</span>
            </v-card-title>
            <v-card-text>
                <v-container>
                    <v-form enctype='multipart/form-data'>
                        <v-row>
                        <v-col cols="12">
                            <v-text-field
                            label="Tên sản phẩm"
                            required
                            v-model="jewelry.jewelryName"
                            ></v-text-field>
                        </v-col>

                        <v-col
                            cols="12"
                            sm="6"
                            md="4"
                        >
                            <v-text-field
                            label="Cân nặng"
                            hint="gam"
                            required
                            v-model="jewelry.jewelryWeight"
                            ></v-text-field>
                        </v-col>

                        <v-col
                            cols="12"
                            sm="6"
                            md="4"
                        >
                            <v-text-field
                            label="Kích thước"
                            hint="cm"
                            v-model="jewelry.jewelrySize"
                            ></v-text-field>
                        </v-col>

                        <v-col
                            cols="12"
                            sm="6"
                            md="4"
                        >
                            <v-select
                                :items="colors"
                                label="Màu sắc"
                                required
                                v-model="jewelry.jewelryColor"
                            ></v-select>
                        </v-col>

                        <v-col
                            cols="12"
                            sm="6"
                            md="6"
                        >
                            <v-text-field
                            label="Giá"
                            hint="$"
                            v-model="jewelry.jewelryPrice"
                            ></v-text-field>
                        </v-col>
                        <v-col
                            cols="12"
                            sm="6"
                            md="6"
                        >
                            <v-select
                                :items="this.listCategory"
                                item-title="categoryName"
                                item-value="categoryId"
                                label="Loại"
                                required
                                v-model="jewelry.categoryId"
                            ></v-select>
                        </v-col>

                        <v-col
                            cols="12"
                        >
                            <v-textarea
                                clearable
                                clear-icon="mdi-close-circle"
                                label="Mô tả"
                                v-model="jewelry.jewelryDescription"
                            ></v-textarea>
                        </v-col>

                        <v-col
                            cols="12"
                        >
                        <v-file-input
                            v-model="jewelry.jewelryImages"
                            accept="image/png, image/jpeg, image/bmp"
                            multiple
                            prepend-icon="mdi-camera"
                        >
                            <template v-slot:selection="{ fileNames }">
                            <template v-for="fileName in fileNames" :key="fileName">
                                <v-chip
                                size="small"
                                label
                                color="primary"
                                class="me-2"
                                >
                                {{ fileName }}
                                </v-chip>
                            </template>
                            </template>
                        </v-file-input>
                        </v-col>
                        
                        <v-col cols="12" >
                            <v-row>
                                <v-col md="3" v-for="(file, index) in jewelry.jewelryImages" :key="index">
                                    <v-btn variant="text" icon="mdi-delete" @click="remove(index)"></v-btn>
                                    <img :src="getImageUrl(file)" height="200" width="200"/>
                                </v-col>
                            </v-row>
                        </v-col>
                        </v-row>
                    </v-form>
                </v-container>
            </v-card-text>
            <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
                color="blue-darken-1"
                variant="text"
                @click="dialog = false"
            >
                Close
            </v-btn>
            <v-btn
                color="blue-darken-1"
                variant="text"
                @click=" this.add"
            >
                Save
            </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
import { mapGetters, mapMutations, mapActions } from 'vuex'
import axios from 'axios'
export default {
    name: 'AdminAddJewelry',
    data () {
      return {
        colors: ['Vàng', 'Bạc', 'Kim cương', 'Bạch kim'],
        files: [],
        jewelry: {
          jewelryName: '',
          jewelryDescription: '',
          jewelryWeight: '',
          jewelrySize: '',
          jewelryPrice: '',
          jewelryColor: '',
          categoryId: '',
          jewelryImages: [],
        },
      }
    },
    props:['dialogAdd'],
    computed:{
        ...mapGetters(['listCategory']),
        dialog:{
            get(){
                return this.dialogAdd;
            },
            set(value){
                if(!value){
                    this.$emit('close');
                }
            }
        }
    },
    created(){
        this.getCategories();
    },
    methods: {
        ...mapActions(['getCategories', 'addJewelry']),
        getImageUrl(file) {
            if (file) {
                return URL.createObjectURL(file);
            }
            return '';
        },
        remove (index) {
            this.jewelry.jewelryImages.splice(index, 1)
        },
        add(){
            const formData = new FormData();

            formData.append('jewelryName', this.jewelry.jewelryName);
            formData.append('jewelryDescription', this.jewelry.jewelryDescription);
            formData.append('jewelryWeight', this.jewelry.jewelryWeight);
            formData.append('jewelrySize', this.jewelry.jewelrySize);
            formData.append('jewelryColor', this.jewelry.jewelryColor);
            formData.append('jewelryPrice', this.jewelry.jewelryPrice);
            formData.append('categoryId', this.jewelry.categoryId);

            // Thêm ảnh vào FormData
            for (let i = 0; i < this.jewelry.jewelryImages.length; i++) {
                console.log(this.jewelry.jewelryImages[i]);
                formData.append('jewelryImages', this.jewelry.jewelryImages[i]);
            }

            this.addJewelry(formData)
            .then(response =>{
                this.$emit('close');
                this.$emit('updateData');
            })
            .catch(error=> {
                console.log(error);
            })
        }

    },
}
</script>

<style>

</style>