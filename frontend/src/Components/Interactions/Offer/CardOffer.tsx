import React, { JSX, SyntheticEvent } from 'react'
import { Offer } from '../../../product';
import { Link } from 'react-router-dom';

interface Props {
    id: number;
    offerResult: Offer;
    onOfferCreate: (e: SyntheticEvent) => void;
}

const CardOffer: React.FC<Props> = ({ offerResult }: Props) : JSX.Element => {

  return (           
    <div className="text-sm leading-6 mr-5">
      <figure className="flex flex-col-reverse items-center justify-center bg-slate-100 rounded-xl p-6 max-w-md mx-auto">
        <blockquote className="mt-6 text-slate-700 text-center">
          <p>{offerResult.offerId || 'No Offer ID'}</p>
          <p>{offerResult.expirationDate || 'No Date Available'}</p>
        </blockquote>
        <figcaption className="flex items-center space-x-4">
          <Link
            to={`/product/${offerResult.offerId}`}
            className="text-base text-slate-900 font-semibold"
          >
            {offerResult.quantity ?? 'N/A'}
          </Link>
        </figcaption>
      </figure>
    </div>
  )
}

export default CardOffer;