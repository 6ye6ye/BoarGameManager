<template>
    <footer aria-label="Site Footer" class="bg-gradient-to-r from-blue-500 to-purple-800 ">
        <div class="mx-auto max-w-screen-xl px-4 py-6 px-6 ">
            <div class="flex items-center justify-between">
                <div class="flex items-center">
                    <img class=" icon w-14 h-14" :src="require('/src/assets/icon-main.png')" />
                    <div class="text-white  ml-2 text-xl">
                        Board games
                    </div>
                </div>
                <nav  >
                    <ul class="flex flex-wrap justify-center gap-6 ">
                        <li>
                            <a class="text-white shadow-black hover:text-green-200" href="">
                                About
                            </a>
                        </li>
                        <li>
                            <a class="text-white  hover:text-green-300" href="">
                                Help
                            </a>
                        </li>
                        <li>
                            <a class="text-white hover:text-green-500" href="">
                                Privacy
                            </a>
                        </li>
                        <li>
                            <a class="text-white  hover:text-green-500" href="">
                                Contacts
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
            <p class="mt-6 text-center text-sm text-white hover:text-green-200 lg:text-right">
                Copyright &copy; 2022. All rights reserved.
            </p>
        </div>
    </footer>
</template>
