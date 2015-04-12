/*
returns number of matching addresses
pStartAddr, pEndAddr are refined ranges in search

bArray is byte array to search
size is the memory size of bArray
*/
unsigned long FindMem(DWORD *pStartAddr, DWORD *pEndAddr, const BYTE *bArray, size_t size)
{
	unsigned long counter = 0UL;


	DWORD dwStartAddr = *pStartAddr;
	DWORD dwEndAddr = *pEndAddr;

	DWORD dwSearchAddr = dwStartAddr;

	MEMORY_BASIC_INFORMATION mbi;
	while (dwSearchAddr <= dwEndAddr)
	{
		VirtualQuery( (LPCVOID)dwSearchAddr, &mbi, sizeof(mbi) ); //find next memory block
		if (mbi.Protect & PAGE_READWRITE) //check mem region characteristics
		{
			/* sets search start pointer */
			DWORD dwSubSearch = (dwSearchAddr > (DWORD)mbi.BaseAddress) ? dwSearchAddr-(DWORD)mbi.BaseAddress : 0; //for recursive calls
			dwSearchAddr = (DWORD)mbi.BaseAddress;
      /* start searching a memory block */
			while (dwSubSearch+size <= mbi.RegionSize)
			{
				DWORD dwSubAddr = dwSearchAddr + dwSubSearch;
				if (memcmp((const void *)dwSubAddr, bArray, size) == 0) //match?
				{
					if (counter == 0)
						*pStartAddr = dwSubAddr;
					*pEndAddr = dwSubAddr;
					counter++; //increment the sub-search pointer
				}
				dwSubSearch++;
			}
		}
		dwSearchAddr += mbi.RegionSize; //increment the search pointer
	}
	return counter;
}
