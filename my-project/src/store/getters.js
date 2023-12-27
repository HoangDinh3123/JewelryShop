import state from "./state";

export default{
    listJewelry: state => state.listJewelry,
    jewelry: state => state.jewelry,
    cart: state => state.cart,
    listCategory: state => state.listCategory,
    category: state => state.category,
    listOrder: state => state.listOrder,
    listOrderDetail: state => state.listOrderDetail,
    listCustomer : state => state.listCustomer,
    user: state => state.user,
    review: state => state.review,
    listReview: state => state.listReview,
    order: state => state.order
}