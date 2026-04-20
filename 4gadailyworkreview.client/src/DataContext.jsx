import { createContext, useState, useContext } from 'react';

export const DataContext = createContext();
export default function DataProvider({ children }) {
    const [data, setData] = useState(null);
    const [cardsNumber, setCardsNumber] = useState(null);
    return (
        <DataContext.Provider value={{ data, setData, cardsNumber, setCardsNumber }}>
            {children}
        </DataContext.Provider>
    );
}