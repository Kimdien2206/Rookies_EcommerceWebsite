import { createContext, ReactNode, useEffect, useState } from "react";
import LocalStorage from "../helper/localStorage";
import { UserLocalStorage } from "../types/User";

export const AppContext = createContext<AppContextProps | null>(null);

type AppProviderProps = {
  children: ReactNode;
}

type AppContextProps = {
  user: UserLocalStorage | null;
  setUser: React.Dispatch<React.SetStateAction<UserLocalStorage | null>>;
}

export const AppProvider = ({ children }: AppProviderProps) => {
  const [user, setUser] = useState<UserLocalStorage | null>(
    LocalStorage.getItem("user")
  );

  useEffect(() => {}, [user])

  return (
    <AppContext.Provider
      value={{
        user,
        setUser,
      }}
    >
      {children}
    </AppContext.Provider>
  );
};
