﻿/*
 * Modulo Open Distributed SCAP Infrastructure Collector (modSIC)
 * 
 * Copyright (c) 2011-2015, Modulo Solutions for GRC.
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * - Redistributions of source code must retain the above copyright notice,
 *   this list of conditions and the following disclaimer.
 *   
 * - Redistributions in binary form must reproduce the above copyright 
 *   notice, this list of conditions and the following disclaimer in the
 *   documentation and/or other materials provided with the distribution.
 *   
 * - Neither the name of Modulo Security, LLC nor the names of its
 *   contributors may be used to endorse or promote products derived from
 *   this software without specific  prior written permission.
 *   
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modulo.Collect.Probe.Unix.Probes.FileProbes.File;
using Modulo.Collect.OVAL.SystemCharacteristics;
using Modulo.Collect.OVAL.Common;

namespace Modulo.Collect.Probe.Unix.Test.ProberTests.File
{
    [TestClass]
    public class UnixFileItemFactoryTests
    {
        [TestMethod, Owner("lfernandes")]
        public void Should_be_possible_to_create_file_item_from_a_path()
        {
            var unixFileItem = new UnixFileItemFactory().CreateFileItem("/etc/config/start.sh");

            AssertFileItemEntity(unixFileItem.filepath, "/etc/config/start.sh");
            AssertFileItemEntity(unixFileItem.path, "/etc/config/");
            AssertFileItemEntity(unixFileItem.filename, "start.sh");
        }
        
        [TestMethod, Owner("lfernandes")]
        public void Should_be_possible_to_create_file_item_from_a_path_without_filename_ie_a_directory_path()
        {
            var pathSample = "/etc/config/";
            var unixFileItem = new UnixFileItemFactory().CreateFileItem(pathSample);

            AssertFileItemEntity(unixFileItem.filepath, pathSample);
            AssertFileItemEntity(unixFileItem.path, pathSample);
            Assert.IsNull(unixFileItem.filename);
        }

        private void AssertFileItemEntity(EntityItemStringType entityToAssert, String expectedEntityValue)
        {
            Assert.IsNotNull(entityToAssert, "A null entity was found.");
            Assert.AreEqual(SimpleDatatypeEnumeration.@string, entityToAssert.datatype, "Unexpected datatype was found.");
            Assert.AreEqual(expectedEntityValue, entityToAssert.Value, "Unexpected entity value was found.");
        }
    }
}
