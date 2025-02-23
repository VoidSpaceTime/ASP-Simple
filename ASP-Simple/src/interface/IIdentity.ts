

export interface IRegisterUser {
    Name: string;
    Password: string;
    Email?: string;
    PhoneNumber: string;
}
//UserResponse(user.Id, user.PhoneNumber ?? string.Empty, user.CreationTime)
export interface IUserInfo {
    Id: string;
    PhoneNumber: string;
    CreationTime: Date;
}
