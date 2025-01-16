import React, { SyntheticEvent } from 'react'
import CardRequest from './CardRequest';
import { Request } from '../../../product'

interface Props {
    requestsResult: Request[] | null;
    onRequestCreate: (e: SyntheticEvent) => void;
}

const ListRequests: React.FC<Props> = ({ requestsResult, onRequestCreate }) => {
  if (!requestsResult || !Array.isArray(requestsResult) || requestsResult.length === 0) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <p className="text-xl font-semibold text-gray-600 text-center">
          No request found
        </p>
      </div>
    );
  }
  
  return (
    <div className="grid grid-cols-1 gap-4 md:grid-cols-2 lg:grid-cols-3">
      {requestsResult.map((request) => (
        <CardRequest
          id={request.requestId} // Assuming `requestId` exists in the `Request` type
          key={request.requestId} // Fixed: Correct key usage
          requestResult={request}
          onRequestCreate={onRequestCreate}
        />
      ))}
    </div>
  );
};

export default ListRequests;
