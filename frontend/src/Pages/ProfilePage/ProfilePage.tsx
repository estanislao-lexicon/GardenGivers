import React, { useEffect, useState } from 'react'
import { searchUserProfile } from '../../api';
import { UserProfile } from '../../Models/User';
import './ProfilePage.css';
import avatar from "./avatar.png";


interface Props {}

const ProfilePage = (props: Props) => {
  const [userProfile, setUserProfile] = useState<UserProfile | null>(null);

  // Utility function to validate the user profile
  const isValidUserProfile = (data: any): data is UserProfile => {
    return (
      typeof data === 'object' &&
      'username' in data &&
      'email' in data &&
      'token' in data &&
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
          console.error("Invalid user profile data:", result);
        }        
      } catch (error) {
        console.error('Error fetching user profile:', error);
      }
    };

    fetchUserProfile();
  }, []);
  
  return (
    <div className="text-sm leading-6">
      <figure className="flex flex-col-reverse items-center justify-center bg-slate-100 rounded-xl p-6 max-w-md mx-auto">
        <blockquote className="mt-6 text-slate-700">
          <p></p>
        </blockquote>
        <figcaption className="flex items-center space-x-10">
          <img src={avatar} alt='avatar' className="w-20 h-20 rounded-full object-cover"/>
          <div className="flex-auto">
            {userProfile ? (
              <>
                <div className="text-base text-slate-900 font-semibold">
                  {userProfile.firstName} {userProfile.lastName}
                </div>
                <div className="mt-0.5 text-slate-700">
                  {userProfile.email}
                </div>
                <div className="mt-0.5 text-slate-700">
                  {userProfile.address}
                </div>
                <div className="mt-0.5 text-slate-700">
                  {userProfile.postNumber}, {userProfile.city} 
                </div>
              </>
            ) : (
              <p>Loading profile...</p>
            )}
          </div>
        </figcaption>
      </figure>
    </div>            
  )
};

export default ProfilePage;
