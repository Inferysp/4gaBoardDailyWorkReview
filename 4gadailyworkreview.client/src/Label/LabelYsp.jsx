export default function LabelYsp({ text }) {
    const isVisible = text
    return (
        <>
            {isVisible != null &&
                <div className="h-full box-border p-2 text-justify max-w-200 text-black bg-gray-200 border-1 border-solid border-pink" >
                    {/*<article className="text-wrap">*/}
                        <p>{text}</p>
                    {/*</article>*/}
                </div>
            }
        </>
    )
}