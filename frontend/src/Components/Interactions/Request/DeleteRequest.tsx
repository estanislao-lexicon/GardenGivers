import React, { SyntheticEvent } from 'react'

interface Props {
    onRequestDelete: (e: SyntheticEvent) => void;
    requestCreated: string;
}

const DeleteRequest = ({onRequestDelete, requestCreated}: Props) => {
  return (
    <div>
        <form onSubmit={onRequestDelete}>
          <input hidden={true} value={requestCreated} />
          <button className="block w-full py-3 text-white duration-200 border-2 rounded-lg bg-red-500 hover:text-red-500 hover:bg-white border-red-500">
            X
          </button>
        </form>    
    </div>
  )
}

export default DeleteRequest;
