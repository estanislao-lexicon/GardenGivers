import React, { SyntheticEvent } from 'react'

interface Props {
    onRequestCreate: (e: SyntheticEvent) => void;
    productId: number;
    productName: string;
}

const AddRequest = ({onRequestCreate, productName}: Props) => {
  return ( 
    <form onSubmit={onRequestCreate}>        
        <input readOnly={true} hidden={true} value={productName}/>       
        <button
          type="submit"
          className="p-2 px-8 text-white bg-darkBlue rounded-lg hover:opacity-70 focus:outline-none"
        >
          Request
        </button>

    </form>  
  );
};

export default AddRequest;
