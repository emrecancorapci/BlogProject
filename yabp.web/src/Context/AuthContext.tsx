import { createContext, useState } from 'react';

interface AuthContextInterface {
  auth: boolean
  setAuth: (auth: boolean) => void
}

const authCtxDefaultValue = {
  auth: false,
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  setAuth: () => {}
}

const AuthContext = createContext<AuthContextInterface>(authCtxDefaultValue);

export function AuthProvider (
  { children }: { children: JSX.Element }): JSX.Element {
  const [auth, setAuth] = useState<boolean>(authCtxDefaultValue.auth);

  return (
        <AuthContext.Provider value={{ auth, setAuth }}>
            {children}
        </AuthContext.Provider>
  );
}

export default AuthContext;
