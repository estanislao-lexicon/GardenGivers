import React, { SyntheticEvent } from 'react'

interface Props {
    onOfferDelete: (e: SyntheticEvent) => void;
    offerCreated: string;
}

const DeleteOffer = ({onOfferDelete, offerCreated}: Props) => {
  return (
    <div>
        <form onSubmit={onOfferDelete}>
          <input hidden={true} value={offerCreated} />
          <button className="block w-full py-3 text-white duration-200 border-2 rounded-lg bg-red-500 hover:text-red-500 hover:bg-white border-red-500">
            X
          </button>
        </form>    
    </div>
  )
}

export default DeleteOffer