import React, { useEffect, useState } from 'react'
import { searchUserProfile } from '../../api';
import { UserProfile } from '../../Models/User';
import './ProfilePage.css';
import avatar from "./avatar.png";


interface Props {}

const ProfilePage = (props: Props) => {
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);
  const [error, setError] = useState<string | null>(null);

  // Utility function to validate the user profile
  const isValidUserProfile = (data: any): data is UserProfile => {
    return (
      typeof data === 'object' &&
      'userId' in data &&
      'username' in data &&
      'email' in data &&      
      'firstName' in data &&
      'lastName' in data &&
      'city' in data &&
      'address' in data &&
      'postNumber' in data
    );
  };

  useEffect(() => {
    const fetchUserProfile = async () => {
      try {
        const result = await searchUserProfile();
        
        if(isValidUserProfile(result)) {
          console.log('User profile:', result);
          setUserProfile(result);
        }else {
          console.error('Invalid user profile data:', result);
          setError('Invalid profile data received.');
        }        
      } catch (error) {
        console.error('Error fetching user profile:', error);
        setError('Failed to load profile. Please try again later.');
      }
    };

    fetchUserProfile();
  }, []);
  
  return (
    <div className="text-sm leading-6">
    <figure className="flex flex-col-reverse items-center justify-center bg-slate-100 rounded-xl p-6 max-w-md mx-auto">
      <figcaption className="flex items-center space-x-10">
        <img
          src={avatar}
          alt="avatar"
          className="w-20 h-20 rounded-full object-cover"
          onError={(e) => (e.currentTarget.src = 'default-avatar.png')}
        />
        <div className="flex-auto">
          {error ? (
            <p className="text-red-500 text-center">{error}</p>
          ) : userProfile ? (
            <>
              <div className="text-base text-slate-900 font-semibold">
                {userProfile.firstName} {userProfile.lastName}
              </div>
              <div className="mt-0.5 text-slate-700">{userProfile.email}</div>
              <div className="mt-0.5 text-slate-700">{userProfile.address}</div>
              <div className="mt-0.5 text-slate-700">
                {userProfile.postNumber}, {userProfile.city}
              </div>
            </>
          ) : (
            <div className="animate-pulse space-y-4">
              <div className="h-6 bg-gray-200 rounded w-3/4"></div>
              <div className="h-6 bg-gray-200 rounded w-1/2"></div>
              <div className="h-6 bg-gray-200 rounded w-5/6"></div>
            </div>
          )}
        </div>
      </figcaption>
    </figure>
  </div>           
  )
};

export default ProfilePage;
