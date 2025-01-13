import React, { SyntheticEvent } from 'react'

interface Props {
    onOfferCreate: (e: SyntheticEvent) => void;
}

const Offer = ({onOfferCreate}: Props) => {
  return ( 
    <form onSubmit={onOfferCreate}>        
        <input readOnly={true} hidden={true} type="text"/>
        <input type="text" placeholder="Offer Price" />
        <input type="text" placeholder="Offer Quantity" />
        <button type="submit">Create Offer</button>
    </form>  
  );
};

export default Offer;
