import React, { useEffect, useState } from 'react'
import {useNavigate } from 'react-router-dom';
import CreditCard from '../../../core/components/CreditCard'
import { applySSNMask, removeSSNMask } from '../../../core/masks/ssnMasks';

const HomePage = () => {
  const [loading, setLoading] = useState(true);
  const [document, setDocument] = useState("");
  
  const navigate = useNavigate();

  useEffect(() => {
    new Promise(resolve => setTimeout(resolve, 2000));
    setLoading(false);
  }, [loading]);

  const handleSubmit = (event: any) => {
    event.preventDefault();
    
    if(removeSSNMask(document) === "519408548") // 001687894
    {
      navigate("/proposals/consult");
      console.log("Search");
    }
    else {
      navigate("/proposals/persornal-informations");
    }
  }

  return (
    loading ? <>loading</> :
    <div className='w-full h-460 ' >
        <header className="h-460" style={{ backgroundImage: `url(/assets/header-bg.svg)` }}>
          <div className='pb-56'>
            <div className='container-xl px-32 pt-8 flex w-full justify-between'>
              <div className='w-52'>
                <h1 className='font-playfair text-3xl text-white'>Venture Bank</h1>
              </div>
              <div className=''>
                <form action="submit" onSubmit={(e) => handleSubmit(e)}>
                    <div className='flex w-80 border-solid border-2 border-sky-500 '>
                      <input type="text" id="first_name" className="bg-white text-indigo-300 text-sm w-full pl-2.5 font-roboto" placeholder="Social Number (SSN)" required onChange={(e) => setDocument(applySSNMask(e.target.value))} value={document} />
                      <button type='submit' className='button p-2 bg-[#2BA9E1] text-white font-roboto_bold'>ORDER</button>
                    </div>
                </form>
              </div>
            </div>
          </div>
          <div className='flex container-xl px-32 pt-8 w-full'>
            <div className='w-full'>
              <h2 className='font-poppins text-6xl text-white'>
                Anytime, anywhere
              </h2>
            </div>
            <div className='w-full flex justify-end'>
              <CreditCard placeholder='Noah Campbell'/>
            </div>
          </div>
        </header>
        <main className='bg-[#E5E5E5] container-xl px-32 pt-8 flex w-full h-full'>
          <section className='mt-20 w-full'>
            <h2 className='text-[#191B47] text-2xl'>Our benefits</h2>

            <div className='flex flex-row items-center gap-5'>
              <div className='flex flex-col items-center justify-center gap-2 mt-6'>
                <div className="flex items-center justify-center w-24 h-24 min-h-24 bg-white rounded-full shadow-lg">
                  <img src="/assets/icons/installments.svg" alt="" className='w-12 h-12'/>
                </div>
                <h3 className='text-[#191B47] text-center'>Pay all in interest-free <br/> installments.</h3>
              </div>

              <div className='flex flex-col items-center justify-center p-5 gap-2'>
                <div className="flex items-center justify-center w-24 h-24 min-h-24 bg-white rounded-full shadow-lg">
                  <img src="/assets/icons/offers.svg" alt="" className='w-12 h-12'/>
                </div>
                <h3 className='text-[#191B47] text-center'>Offers of the Week</h3>
              </div>

              <div className='flex flex-col items-center justify-center p-5 gap-2 mt-6'>
                <div className="flex items-center justify-center w-24 h-24 min-h-24 bg-white rounded-full shadow-lg">
                  <img src="/assets/icons/cashback.svg" alt="" className='w-12 h-12 mt-3'/>
                </div>
                <h3 className='text-[#191B47] text-center'>Receive cashback <br/>here</h3>
              </div>

              <div className='flex flex-col items-center justify-center p-5 gap-2'>
                <div className="flex items-center justify-center w-24 h-24 min-h-24 bg-white rounded-full shadow-lg">
                  <img src="/assets/icons/experience.svg" alt="" className='w-12 h-12'/>
                </div>
                <h3 className='text-[#191B47] text-center'>Simple experience</h3>
              </div>

              <div className='flex flex-col items-center justify-center p-5 gap-2'>
                <div className="flex items-center justify-center w-24 h-24 min-h-24 bg-white rounded-full shadow-lg">
                  <img src="/assets/icons/security.svg" alt="" className='w-12 h-12'/>
                </div>
                <h3 className='text-[#191B47] text-center'>Purchase security</h3>
              </div>
            </div>
          </section>
        </main>
        <footer className='bg-[#5352B7] container-xl px-32 p-5 flex w-full justify-center'>
          <span className='text-white'>Copyright © 2024 Venture Bank.</span>
        </footer>
    </div>
  )
}

export default HomePage
