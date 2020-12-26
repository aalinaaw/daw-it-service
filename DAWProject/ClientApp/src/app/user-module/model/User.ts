export class User {
  id: string;
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  token: string;
  userType: UserType;
}

export class UserType {
  id: string;
  type: string;
}
