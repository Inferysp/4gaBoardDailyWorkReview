import Btn from './components/BTN/Btn.jsx';
import CollectionCardsYsp from './components/collection/CollectionCardsYsp.jsx';
import DatePicker from './components/datePicker/DatePicker.jsx';
import React, { useState } from 'react';

function App() {
    const [selectedDate, setSelectedDate] = useState(new Date());

    return (
        <div>
            <div className="MenuBar relative static text-center content-center box-border z-0 top-0 width-100 h-20 bg-gradient-to-l from-transparent to-slate-800">
                <div class="flex justify-between ...">
                    <div className="p-4">
                        <h2>4gaDWR</h2>
                    </div>
                    <div className="p-4">
                        <h2>4gaBoard Daily Work Review</h2>
                    </div>
                    <div className="p-4">
                        <p>&copy; 2026 INFERYSP</p>
                    </div>
                </div>
            </div>
            <div className="body bg-slate-800">
                <div className="statisticBar z-1 mx-100 left-0 bg-slate-200 p-7">
                    <DatePicker date={selectedDate} onDateChange={setSelectedDate} />
                <div className="grid grid-cols-1 gap-6">
                    <CollectionCardsYsp day={selectedDate} />
                </div>
                <Btn cardId="1699997500410169099" />
                </div>
            </div>
            <div className="footer bg-slate-800">
                <div class="flex justify-between ...">asdad</div>
            </div>
        </div>
    );
    
}

export default App;