<template>

    <el-tabs v-model="activeName" @tab-click="" class="w-full">
        <el-tab-pane label="上传图文" name="first">
            <div class="grid gap-2 ml-2">
                <el-upload v-model:file-list="fileList"
                    action="https://run.mocky.io/v3/9d059bf9-4660-45f2-925d-ce80ad6c4d15" list-type="picture-card"
                    :on-preview="handlePictureCardPreview" :on-remove="handleRemove">
                    <el-icon>
                        <Plus />
                    </el-icon>
                </el-upload>

                <el-dialog v-model="dialogVisible">
                    <img w-full :src="dialogImageUrl" alt="Preview Image" />
                </el-dialog>
                <el-input v-model="article.title" style="width: 30rem" maxlength="20" placeholder="填写标题" show-word-limit
                    type="text" />
                <!-- <MdEditor v-model="article.content" @onUploadImg="onUploadImg" /> -->
                <div class="h-[8rem]">

                    <el-input v-model="article.content" maxlength="1000" placeholder="填写内容" show-word-limit
                        type="textarea" rows="5" />
                </div>
                <div class="w-10">
                    <el-button type="primary" size="medium" @click="">发布</el-button>
                </div>

            </div>
        </el-tab-pane>
    </el-tabs>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import { MdEditor } from 'md-editor-v3';
import { ElMessage } from 'element-plus'
import { Plus } from '@element-plus/icons-vue'
import 'md-editor-v3/lib/style.css';
import type { UploadProps, UploadUserFile } from 'element-plus'


let activeName = ref('first');
let fileList = reactive([]);
const dialogImageUrl = ref('')
const dialogVisible = ref(false)
let article = reactive({
    content: '',
    title: '',
    fileList: [],
    dialogImageUrl: '',
    dialogVisible: false,
})

const handleRemove: UploadProps['onRemove'] = (uploadFile, uploadFiles) => {
    console.log(uploadFile, uploadFiles)
}

const handlePictureCardPreview: UploadProps['onPreview'] = (uploadFile) => {
    dialogImageUrl.value = uploadFile.url!
    dialogVisible.value = true
}
/* const onUploadImg = (file: UploadUserFile) => {
    console.log(file)
    return new Promise((resolve, reject) => {
        const reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onload = () => {
            resolve({ url: reader.result as string })
        }
        reader.onerror = (error) => {
            reject(error)
        }
    })
} */
</script>