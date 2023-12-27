<template>
    <v-row justify="center">
      <v-dialog
        v-model="dialog"
        persistent
        width="1024"
      >
        <v-card>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col md="7">
                <v-carousel  hide-delimiters>
                    <v-carousel-item
                        v-for="(item, index) in this.data.JewelryImage"
                        :key="index"
                        :src="item"
                        cover
                        ></v-carousel-item>
                  </v-carousel>
                </v-col>

                <v-col md="5">

                    <span class="text-h5" style="font-weight: bold;">{{this.data.JewelryName}}</span>
                    <p>$ {{this.data.JewelryPrice}}</p>
                    <p style="color: #7D7D7D; font-size: 14px; margin-top: 10px;">
                      {{this.data.JewelryDescription}}
                    </p>

                    <router-link :to="'/customers/detail-Jewelry/' + this.data.JewelryId + '/' + this.data.CategoryId" style="text-decoration: none; color: black;">Read more</router-link>

                </v-col>
              </v-row>
            </v-container>
          </v-card-text>
          <v-divider></v-divider>
              <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="grey"
                         @click="$emit('close')">
                      Close
                  </v-btn>
              </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </template>
  <script>
    export default {
      name:'PreDetailJewelry',
      data(){
          return{
              data:{
                JewelryId: '',
                JewelryName: '',
                JewelryPrice: '',
                JewelryImage: '',
                CategoryId: '',
                JewelryDescription: '',
              },
          }
      },
      props:['dialogDetail', 'currentItem'],
      computed:{
          dialog:{
              get(){
                  return this.dialogDetail;
              },
              set(value){
                  if(!value){
                      this.$emit('close');
                  }
              }
          }
      },
      watch:{
        currentItem:function(){
            this.data.JewelryId = this.currentItem.jewelryId;
            this.data.JewelryName = this.currentItem.jewelryName;
            this.data.JewelryPrice = this.currentItem.jewelryPrice;
            this.data.JewelryImage = this.currentItem.jewelryImages;
            this.data.CategoryId = this.currentItem.categoryId;
            this.data.JewelryDescription = this.currentItem.jewelryDescription
        }
    },
    methods:{
    }
}
  </script>