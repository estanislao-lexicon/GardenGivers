import React, { SyntheticEvent } from 'react'
import DeleteRequest from './DeleteRequest';
import { Link } from 'react-router-dom';

interface Props {
    requestCreated: string;
    onRequestDelete: (e:SyntheticEvent) => void;
}

const CardRequest = ({requestCreated, onRequestDelete}: Props) => {
  return (           
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
      <Link to={`reqiest/${requestCreated}`} className="pt-6 text-xl font-bold">{requestCreated}</Link>
      <DeleteRequest 
        onRequestDelete={onRequestDelete} 
        requestCreated={requestCreated} 
      />
    </div>    
  )
}

export default CardRequest;
