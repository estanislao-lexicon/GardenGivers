import React, { SyntheticEvent, useEffect, useState } from 'react';
import ListRequests from '../../Components/Interactions/Request/ListRequests';
import { getAllRequests } from '../../api';
import { Request } from '../../product';


interface Props {}

const RequestsPage: React.FC<Props> = () => {
  const [requestsCreated, setRequestsCreated] = useState<string[]>([]);
  const [requestsResult, setRequestsResult] = useState<Request[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  // Fetch all requests when the component mounts
  useEffect(() => {
    const fetchRequests = async () => {
      try {
        const response = await getAllRequests();
        let result;
        if (typeof response === 'string') {
          result = response;
        } else {
          result = await response.json();
        }

        if (typeof result === 'string') {
          setServerError(result);
        } else if (Array.isArray(result)) {
          setRequestsResult(result); // Correctly set the array of requests
        }
      } catch (error) {
        setServerError('Failed to fetch requests');
      }
    };

    fetchRequests();
  }, []); // Empty dependency array ensures this runs once on mount

  // Create a request
  const onRequestCreate = (e: SyntheticEvent) => {
    e.preventDefault();
    const target = e.target as HTMLFormElement;
    const newRequest = (target[0] as HTMLInputElement)?.value;

    if (!newRequest) return;

    if (requestsCreated.includes(newRequest)) {
      alert('Request already exists');
      return;
    }

    setRequestsCreated((prev) => [...prev, newRequest]);
  };

  // Delete a request
  const onRequestDelete = (e: SyntheticEvent) => {
    e.preventDefault();
    const target = e.target as HTMLFormElement;
    const requestToRemove = (target[0] as HTMLInputElement)?.value;

    if (!requestToRemove) return;

    setRequestsCreated((prev) =>
      prev.filter((request) => request !== requestToRemove)
    );
  };

  return (
    <div>
      {serverError && (
        <p className="text-red-500 text-center mb-4">{serverError}</p>
      )}

      <ListRequests
        requestsResult={requestsResult}
        onRequestCreate={onRequestCreate}
      />
    </div>
  )
};

export default RequestsPage;
