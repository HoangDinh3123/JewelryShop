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
                        v-for="(item, index) in this.data.JewelryImages"
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
                      {{ this.data.JewelryDescription }}
                    </p>
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
import actions from '@/store/actions';
import { mapActions } from 'vuex';
    export default {
      name:'AdminDetailJewelry',
      data(){
          return{
              data:{
                JewelryId: '',
                JewelryName: '',
                JewelryPrice: '',
                JewelryDescription: '',
                JewelryImages: ''
              },
              items: [
              ],
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
      created(){
      },
      methods:{
      },
      watch:{
        currentItem:function(){
            this.data.JewelryId = this.currentItem.jewelryId;
            this.data.JewelryName = this.currentItem.jewelryName;
            this.data.JewelryPrice = this.currentItem.jewelryPrice;
            this.data.JewelryDescription = this.currentItem.jewelryDescription;
            this.data.JewelryImages = this.currentItem.jewelryImages;
        }
    },
}
  </script>