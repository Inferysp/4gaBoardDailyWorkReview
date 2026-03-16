export default function LabelYsp({ style, text }) {
    const isVisible = text
    return (
        <>
            {isVisible != null &&
                <div className={`${style}`} >
                    <p>{text}</p>
                </div>
            }
        </>
    )
}