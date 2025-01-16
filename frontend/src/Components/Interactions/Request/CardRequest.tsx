import React, { JSX, SyntheticEvent } from 'react'
import { Request } from '../../../product';
import { Link } from 'react-router-dom';

interface Props {
    id: number;
    requestResult: Request;
    onRequestCreate: (e: SyntheticEvent) => void;
}

const CardRequest: React.FC<Props> = ({ requestResult }: Props) : JSX.Element => {

  return (           
    <div className="text-sm leading-6 mr-5">
      <figure className="flex flex-col-reverse items-center justify-center bg-slate-100 rounded-xl p-6 max-w-md mx-auto">
        <blockquote className="mt-6 text-slate-700 text-center">
          <p>{requestResult.offerId || 'No Offer ID'}</p>
          <p>{requestResult.dateCreated || 'No Date Available'}</p>
        </blockquote>
        <figcaption className="flex items-center space-x-4">
          <Link
            to={`/product/${requestResult.requestId}`}
            className="text-base text-slate-900 font-semibold"
          >
            {requestResult.quantity ?? 'N/A'}
          </Link>
        </figcaption>
      </figure>
    </div>
  )
}

export default CardRequest;
