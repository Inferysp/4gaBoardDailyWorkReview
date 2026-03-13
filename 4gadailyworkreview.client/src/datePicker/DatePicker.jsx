import { useState } from "react";
import { addDays, format, parseISO } from "date-fns";

export default function DatePicker({date, onDateChange }) {
    const handlePrev = () => onDateChange( addDays(date, -1) );
    const handleNext = () => onDateChange(addDays(date, 1));
    const handleDateChange = (e) => onDateChange(parseISO(e.target.value));

    return (
        <div style={{ display: "flex", gap: "1rem", alignItems: "center" }}>
            <button onClick={handlePrev}>←</button>
            <input
                type="date"
                value={format(date, "yyyy-MM-dd")}
                onChange={handleDateChange}
            />
            <button onClick={handleNext}>→</button>
        </div>
    );
}