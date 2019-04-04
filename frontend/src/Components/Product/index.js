import React from 'react';
import './Product.css';

const Product = (props) => {

    const productData = props.data;

    return (
        <div className='item'>
            <img src={productData.product_image}/>
            <p>{productData.product_brand}</p>
            <p>{productData.product_name}</p>
            <p>{productData.product_price}kr</p>
        </div>
    );
};

export default Product;