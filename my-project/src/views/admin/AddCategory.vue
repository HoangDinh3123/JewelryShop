    <template>
        <v-dialog
        v-model="dialog"
        persistent
        width="1024"
        >
            <v-card>
                <v-card-title>
                    <span class="text-h5">Thêm Mới Loại Sản Phẩm</span>
                </v-card-title>
                <v-card-text>
                    <v-container>
                        <v-form>
                        <v-row>
                        <v-col cols="12">
                            <v-text-field
                            label="Tên loại sản phẩm"
                            required
                            v-model="category.categoryName"
                            ></v-text-field>
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
                    @click="this.add"
                >
                    Save
                </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </template>

    <script>
    import { mapActions } from 'vuex';
    export default {
        name: 'AddCategory',
        data () {
        return {
            category: {
                categoryName: '',
            }
        }
        },
        props:['dialogAdd'],
        computed:{
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
        methods: {
            ...mapActions(['addCategory']),
            add(){
                this.addCategory(this.category)
                .then(() => {
                    this.$emit('close');
                    this.$emit('updateData');
                })
                .catch(error => {
                    console.error(error);
                })
            },
        },
    }
    </script>

    <style>

    </style>