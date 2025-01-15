export type UserProfileToken = {
    username: string;
    email: string;
    token: string;
};

export type UserProfileLogin = {
    username: string,
    email: string,    
}

export type UserProfile = {
    username: string,
    email: string,
    token: string,
    firstName: string,
    lastName: string,
    city: string,
    address: string,
    postNumber: string,
}
