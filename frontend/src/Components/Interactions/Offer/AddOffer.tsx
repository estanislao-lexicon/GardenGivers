import React, { SyntheticEvent } from 'react'

interface Props {
    onOfferCreate: (e: SyntheticEvent) => void;
    productId: number;
    productName: string;
}

const AddOffer = ({onOfferCreate, productName}: Props) => {
  return ( 
    <form onSubmit={onOfferCreate}>        
        <input readOnly={true} hidden={true} value={productName}/>       
        <button
          type="submit"
          className="p-2 px-8 text-white bg-darkBlue rounded-lg hover:opacity-70 focus:outline-none"
        >
          Add
        </button>

    </form>  
  );
};

export default AddOffer;
